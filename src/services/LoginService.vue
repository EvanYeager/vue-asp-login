<script lang="ts">
import type { VueCookies as VueCookiesType } from 'vue-cookies';
import cookies from 'vue-cookies';

const $cookies = cookies as unknown as VueCookiesType;

export default class LoginService {
    private sessionKeyName = "loginSessionToken";

    constructor() {}
    
    isLoggedIn(): boolean {
        return $cookies.isKey(this.sessionKeyName)
    }

    saveLoginSession(token: string) {
        $cookies.set(this.sessionKeyName, token, "5h");
    }

    removeLoginSession() {
        $cookies.remove(this.sessionKeyName);
    }
}
</script>