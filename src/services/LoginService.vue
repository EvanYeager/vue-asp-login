<script lang="ts">
import type { VueCookies as VueCookiesType } from 'vue-cookies';
import cookies from 'vue-cookies';

const $cookies = cookies as unknown as VueCookiesType;

export default class LoginService {
    constructor() {}
    
    isLoggedIn(): boolean {
        if ($cookies.isKey("loginSessionToken")) {
            console.log('is logged in')
            return true
        }
        else {
            console.log('not logged in')
            return false
        }
        // return $cookies.isKey("loginSessionToken")
    }

    saveLoginSession(token: string) {
        $cookies.set("loginSessionToken", token, "5h");
    }
    // functions: {
    // }
}
</script>