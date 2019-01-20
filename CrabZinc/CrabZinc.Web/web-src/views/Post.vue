<template>
    <div>
        <div class="section">
            <div class="container">
                <h1 class="title">Post!</h1>
                <div class="field">
                    <label class="label">Title</label>
                    <div class="control">
                        <input class="input" type="text" placeholder="Title" v-model="title" />
                    </div>
                </div>
                <div class="field">
                    <label class="label">Content</label>
                    <div class="control">
                        <app-markdown-editor v-model="content"></app-markdown-editor>
                    </div>
                </div>
                <button type="button" class="button" v-on:click="save">Save</button>
            </div>
        </div> 
    </div>
</template>

<script>
    import system from "services/system.js"
    import { PostService } from "services/ApplicationProxy.js";
    import Icon from "components/Common/Icon.vue"
    import MarkdownEditor from "components/Common/MarkdownEditor.vue"

    var postId = parseInt($("#postId").val(), 10) || -1;

    export default {
        data: function () {
            return {
                postId: postId,
                postUuid: "",
                slug: "",
                title: "",
                content: "",
                publishedDate: new Date(),
                visible: true                
            }
        },
        methods: {
            fetchPost() {
                PostService.get(this.postId).then(function (data) {
                    this.update(data);
                }.bind(this),
                function (error) {
                    console.log("Error fetching post: " + error);
                });
            },
            update(post) {
                this.postId = post.postId;
                this.postUuid = post.postUuid;
                this.content = post.content;
                this.slug = post.slug;
                this.title = post.title;                
                this.publishedDate = new Date(post.publishedDate)
                this.visible = post.visible;
           
            },
            clear() {
                this.postId = -1;
                this.postUuid = "";
                this.slug = "";
                this.title = "";
                this.publishedDate = new Date()
                this.visible = "";
            },
            toModel() {
                return {
                    postId: this.postId,
                    title: this.title,
                    content: this.content
                }  
            },
            save() {
                var method = this.postId == -1 ? PostService.create : PostService.update;
                method(this.toModel()).then(function (data) {
                    this.update(data)
                }.bind(this),
                function (error) {
                    console.log("Error saving post: " + error);
                });
            }
        },
        created() {
            if (this.postId !== -1) {
                this.fetchPost();
            }            
        },
        components: {
            "app-icon": Icon,
            "app-markdown-editor": MarkdownEditor
        }
    }
</script>