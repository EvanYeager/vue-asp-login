<script lang="ts">
import { computed, ref } from 'vue';
import CookieService from './CookieService.vue';


export default class LocationService {

    private static instance: LocationService;
    private cookieService = new CookieService();

    private constructor() {
        if (this.cookieService.$cookies.isKey("locations")) {
            const locationCookie = this.cookieService.$cookies.get("locations");
            if (locationCookie)
                this.locations.value = locationCookie;
        }
    }

    public static getInstance(): LocationService {
        if (!LocationService.instance)
            LocationService.instance = new LocationService();
        return LocationService.instance;
    }

    locations = ref<string[]>([]);

    private activeLocation: string | null = this.locations.value[0];

    getLocations = computed(() => {
        return this.locations.value;
    });

    removeLocation(location: string): void {
        const index = this.locations.value.indexOf(location);
        if (index >= 0 && index < this.locations.value.length)
            this.locations.value.splice(index, 1);

        this.updateLocationCookies();
    }

    addLocation(location: string): void {
        this.locations.value.push(location);
        this.updateLocationCookies();
    }

    getActiveLocation = computed(() => {
        return this.locations.value.length > 0 ? this.locations.value[0] : null;
    })

    setActiveLocation(location: string): void {
        const index = this.locations.value.indexOf(location);
        if (index >= 0 && index < this.locations.value.length)
            this.activeLocation = this.locations.value[index];
        else
            this.activeLocation = null;

        this.updateLocationCookies();
    }

    moveLocationToTop(index: number): void {
        if (index >= 0 && index < this.locations.value.length) {
            const location = this.locations.value[index];
            this.locations.value.splice(index, 1);
            this.locations.value.unshift(location);
        }

        this.updateLocationCookies();
    }


    private updateLocationCookies() {
        console.log('updating location cookies. ', JSON.stringify(this.locations.value));
        this.cookieService.removeCookie("locations");
        this.cookieService.addCookie("locations", JSON.stringify(this.locations.value));
    }
}

</script>