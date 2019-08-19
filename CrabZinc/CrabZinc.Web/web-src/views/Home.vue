<template>
    <div>
        <div class="callout" :style="'background-image: url( ' + backgroundImage + ')'">
            <div class="callout-content">
                <h1>Mitchell Caisse</h1>
                <h2>Thoughts 'n' Stuff</h2>
            </div>
        </div>
        <div class="container">
            <ul>
                <li class="box" v-for="post in posts">
                    <p class="is-size-6">{{ post.createDate | formatDate("MMMM DD, YYYY") }}</p>
                    <p class="is-size-3"><a :href="`${baseUrl}post/${post.slug}/`">{{ post.title }}</a></p>
                    <p class="is-size-5">{{ post.description }}</p>
                </li>
            </ul>
        </div>  
    </div>
</template>

<script>
    import background from "img/background.jpg";
    import system from "services/System.js"
    import { PostService } from "services/ApplicationProxy.js";    
    
    export default {
        name: "home",
        data: function() {
            return {
                posts: [],
                baseUrl: system.baseUrl,
                backgroundImage: background
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
    .callout {        
        position: relative;
        height: 100vh;
        min-height: 500px;
        max-height: 1080px;
        overflow: hidden;
        background-size: cover;
        margin-bottom: 20px;
        border-radius: 0;
    }
    .callout h1 {
        text-transform: uppercase;
        font-size: 5em;
        font-weight: 900;
    }
    
    .callout h2 {
        font-weight: 500;
        font-size: 2.25em;
        margin-bottom: 30px;
    }
    
    .callout .callout-content {
        position: absolute;
        top: 50%;
        left: 50%;
        -webkit-transform: translate(-50%, -50%);
        transform: translate(-50%, -50%);
        text-align: center;        
    }
</style>