<script lang="ts">
import type { VueCookies as VueCookiesType } from 'vue-cookies';
import cookies from 'vue-cookies';
import CookieService from './CookieService.vue';

const $cookies = cookies as unknown as VueCookiesType;

export default class LoginService {
    private sessionKeyName = "loginSessionToken";
    private cookieService = new CookieService();

    constructor() {}
    
    isLoggedIn(): boolean {
        return this.cookieService.$cookies.isKey(this.sessionKeyName);
    }

    saveLoginSession(token: string) {
        this.cookieService.addCookie(this.sessionKeyName, token);
    }

    removeLoginSession() {
        this.cookieService.removeCookie(this.sessionKeyName);
    }
}
</script>