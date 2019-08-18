<template>
    <div>
        <ul>
            <li class="box" v-for="post in posts">
                <p class="is-size-5">{{ post.createDate | formatDate("MMMM DD, YYYY") }}</p>
                <p class="is-size-3"><a :href="`${baseUrl}post/${post.slug}/`">{{ post.title }}</a></p>
                <p class="is-size-4">{{ post.description }}</p>
            </li>
        </ul>
    </div>
</template>

<script>
    import system from "services/System.js"
    import { PostService } from "services/ApplicationProxy.js";    
    
    export default {
        name: "home",
        data: function() {
            return {
                posts: [],
                baseUrl: system.baseUrl
            };
        },
        methods: {
            fetchPosts: function() {
                PostService.getNewest().then(function (data) {
                   this.posts = data; 
                }.bind(this),
                function (error) {
                    console.log("Error fetching newest posts");
                });
            }
        },
        created: function() {
            this.fetchPosts();
        }
    }
</script>

<style scoped>

</style>