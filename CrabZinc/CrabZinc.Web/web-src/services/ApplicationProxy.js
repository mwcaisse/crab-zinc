import Proxy from "services/Proxy.js";

var post = {
    get: function(id) {
        return Proxy.get("post/" + id);
    },
    getAll: function() {
        return Proxy.get("post/");
    },
    getNewest: function () {
        return Proxy.get("post/newest");
    },
    create: function(post) {
        return Proxy.post("post/", post);
    },
    update: function(post) {
        return Proxy.put("post/" + post.postId, post);
    },
    delete: function(id) {
        return Proxy.delete("post/" + id);
    }
};


export {
    post as PostService,
};