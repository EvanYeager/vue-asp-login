<script lang="ts">
import type { VueCookies as VueCookiesType } from 'vue-cookies';
import cookies from 'vue-cookies';

export default class CookieService {
    
    $cookies = cookies as unknown as VueCookiesType;
    
    constructor() {}
    
    addCookie(key: string, value: string) {
        this.$cookies.set(key, value, "24h");
    }
    
    removeCookie(key: string) {
        this.$cookies.remove(key);
    }
    
    doesCookieExist(key: string): boolean {
        return this.$cookies.isKey(key);
    }
}
</script>