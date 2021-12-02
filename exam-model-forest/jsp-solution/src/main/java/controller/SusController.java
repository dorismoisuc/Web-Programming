package controller;

public class SusController
{
    @Override
    @Transactional
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        PrintWriter out = resp.getWriter();
        resp.setContentType("application/json");
        var sess = req.getSession(false);
        if (sess == null){
            resp.setStatus(401);
            out.println(this.mapper.writerFor(ServletResponse.class).writeValueAsString(new ServletResponse("Must be logged in!")));
            return;
        }
        var username = (String)sess.getAttribute("username");
        var userProbe = User.builder().username(username).build();
        User user = userRepo.findOne(Example.of(userProbe)).orElse(null);

        if (user == null){
            resp.setStatus(418);
            out.println(this.mapper.writerFor(ServletResponse.class).writeValueAsString(new ServletResponse("Idk how someone would even get here but i must treat this error anyways. If you get this then please inform.")));
            return;
        }

        long location_id;
        try {
            location_id = Long.parseLong(req.getParameter("location_id"));
        }
        catch (NumberFormatException ignored){
            resp.setStatus(401);
            out.println(this.mapper.writerFor(ServletResponse.class).writeValueAsString(new ServletResponse("Parameter location_id must be a number!")));
            return;
        }
        Location location;
        try {
            location = this.locationRepo.getOne(location_id);
        }
        catch (EntityNotFoundException ignored){
            resp.setStatus(404);
            out.println(this.mapper.writerFor(ServletResponse.class).writeValueAsString(new ServletResponse("Location not found!")));
            return;
        }

        var remove = Boolean.parseBoolean(req.getParameter("remove"));
        if (!remove) {
            user.addLocation(location);
        }
        else {
            user.removeLocation(location);
        }
        User savedUser = this.userRepo.save(user);
        out.println(this.mapper.writerFor(UserDTO.class).writeValueAsString(userConverter.convertModelToDto(savedUser)));
    }
}

