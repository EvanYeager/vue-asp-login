<script lang="ts">
import type { VueCookies as VueCookiesType } from 'vue-cookies';
import cookies from 'vue-cookies';
import CookieService from './CookieService.vue';
import axios from 'axios';

const $cookies = cookies as unknown as VueCookiesType;

export default class LoginService {
    private sessionKeyName = "loginSessionToken";
    private cookieService = new CookieService();

    private aspUrl = "https://localhost:7007";

    constructor() {}

    async login(username: string, password: string): Promise<boolean> {
        try {
            const response = await axios.post(`${this.aspUrl}/api/auth/login`, {
                Username: username,
                Password: password
            });
            if (response.status === 200) {
                this.saveLoginSession(response.data);
                return true;
            }
            return false;
        } catch (error) {
            console.error("Login failed:", error);
            return false;
        }
    }
    
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