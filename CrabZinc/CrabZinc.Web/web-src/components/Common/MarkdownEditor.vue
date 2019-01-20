<template>
    <textarea ref="editor"></textarea>
</template>

<script>
    import SimpleMDE from "simplemde";
    import 'simplemde/dist/simplemde.min.css';

     export default {
        name: "app-markdown-editor",
        data: function() {
            return {      
            }
        },    
        props: {
            value: {
                type: String,
                required: false,
                default: ""
            }
        },
        watch: {
            value: function (newValue, oldValue) {       
                if (this.simplemde.value() != newValue) {
                    this.setEditorValue(newValue);
                }                
            }
        },
        methods: {
            updateValue: function (value) {
                this.$emit("input", value);
            },
            setEditorValue: function (value) {
                this.simplemde.value(value);
            }
        },
        mounted() {
            this.simplemde = new SimpleMDE({
                element: this.$refs.editor
            });

            this.simplemde.value(this.value);

            this.simplemde.codemirror.on("change", function () {
                this.updateValue(this.simplemde.value())
            }.bind(this));
        }       
    }
</script>
