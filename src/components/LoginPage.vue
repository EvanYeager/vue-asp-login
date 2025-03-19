<script setup lang="ts">
import LoginService from '@/services/LoginService.vue';

const loginService = new LoginService();
let username: string = "";
let password: string = "";

let failure: boolean = false;

const login = (username: string, password: string) => {
    loginService.login(username, password).then((success) => {
        if (success) {
            console.log("Login successful");
            window.location.href = "/";
        } else {
            failure = true;
        }
    });

}

</script>

<template>
    <p id="note">This application demonstrates login functionality paired with weather api integration that utilizes browser cookies to keep track of your weather locations. The backend will validate your login and send a generated uid, which is then stored in cookies as a user session, so you are able to reload the page and the website state is preserved.</p>

    <p>Log in to use this application</p>
    <input type="text" v-model="username" placeholder="Username">
    <input type="password" v-model="password" @keyup.enter="login(username, password)" placeholder="Password">
    <button @click="login(username, password)">Log in</button>
    <p v-if="failure">Login failed</p>

    <p id="hint">Hint: admin admin is a valid login.</p>
</template>

<style>

#note {
    color: rgba(66, 66, 66, 0.637);
    margin-top: -100px;
    margin-bottom: 100px;
    width: 720px;
}

#hint {
    margin-top: 100px;
}
</style>