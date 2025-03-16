<script lang="ts">
import { computed, ref } from 'vue';


export default class LocationService {

    private static instance: LocationService;

    private constructor() {}

    public static getInstance(): LocationService {
        if (!LocationService.instance)
            LocationService.instance = new LocationService();
        return LocationService.instance;
    }

    locations = ref<string[]>([
        "College Park, MD",
        "Spring Hill, TN",
        "Santa Rosa, CA",
    ]);

    private activeLocation: string | null = this.locations.value[0];

    getLocations = computed(() => {
        return this.locations.value;
    });

    removeLocation(location: string): void {
        const index = this.locations.value.indexOf(location);
        if (index >= 0 && index < this.locations.value.length)
            this.locations.value.splice(index, 1);
    }

    addLocation(location: string): void {
        this.locations.value.push(location);
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
    }
}

</script>