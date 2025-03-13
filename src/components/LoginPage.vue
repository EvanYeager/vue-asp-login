<script>
import LoginService from '@/services/LoginService.vue';

export default {
    mounted() {
        this.$cookies.set("loginSessionToken", "testtesttest");
    }
}
</script>

<template><p>login page works :D</p></template>