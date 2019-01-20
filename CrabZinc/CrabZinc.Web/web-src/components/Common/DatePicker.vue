<template>
    <div class="input-group">
        <input type="text" class="form-control" v-datepicker="date" />     
        <div class="input-group-append">
            <span class="input-group-text">
                <i class="fa fa-calendar"></i>
            </span>
        </div>      
    </div>
</template>

<script>
    import flatpickr from "flatpickr";
    
    export default {
        data: function () {
            return {
            }
        },
        computed: {
            date: function () {
                return this.value;
            }
        },
        props: {
            value: {
                type: Date,
                required: false
            }
        },
        methods: {
            updateValue: function (value) {
                this.$emit("input", value);
            }
        },
        directives: {
            datepicker: {
                bind: function (el, binding, vnode) {
                    var picker = flatpickr(el, {
                        "onChange": function (selectedDates, dateStr, instance) {
                            vnode.context.updateValue(selectedDates[0]);
                            console.log("Date changed: " + selectedDates[0].toUTCString());
                        }
                    });                 
                    picker.setDate(binding.value, false);
                },
                update: function (el, binding) {                    
                    el._flatpickr.setDate(binding.value, false);
                }
            }
        }     
    }
</script>