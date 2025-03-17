<script setup lang="ts">
import { ref } from 'vue'
import LocationService from '@/services/LocationService.vue';

const locationService = LocationService.getInstance();
let locations = ref(locationService.locations);

// list of location html elements
const listItems = ref<HTMLElement[]>([]);

const handleMouseMove = (event: MouseEvent, index: number): void => {
  const item = listItems.value[index];
  if (!item) return;
  
  const rect = item.getBoundingClientRect();
  const x = event.clientX - rect.left;
  const y = event.clientY - rect.top;
  
  item.style.setProperty('--x', `${x}px`);
  item.style.setProperty('--y', `${y}px`);
  
  const centerX = rect.width / 2;
  const centerY = rect.height / 2;
  const rotateX = (y - centerY) / 10;
  const rotateY = (centerX - x) / 10;
  
  item.style.transform = `perspective(500px) rotateX(${rotateX}deg) rotateY(${rotateY}deg)`;
};

const handleMouseLeave = (index: number): void => {
  const item = listItems.value[index];
  if (!item) return;
  
  item.style.transform = 'perspective(500px) rotateX(0) rotateY(0)';
};

const removeLocation = (index: number): void => {
    locationService.removeLocation(locations.value[index]);
}


</script>
<template>
    <h1>Vue Weather App</h1>
    
    <h2 v-if="locations.length > 0">Your Locations</h2>
    <h2 v-else>Add a location to get started!</h2>
    <ul>
        <li v-for="(location, index) in locations"
            :key="index"
            ref="listItems"
            @mousemove="handleMouseMove($event, index)"
            @mouseleave="handleMouseLeave(index)">
            {{ location }}
            <span class="close-btn" @click.stop="removeLocation(index)">×</span>
        </li>
    </ul>
</template>

<style>
    h1 {
        margin: 70px;
        margin-top: 0;
        text-shadow: 1px 1px 2px black;
    }

    h2 {
        margin: 40px;
        margin-bottom: 20px;
        font-weight: bold;
        min-width: 300px;
        border-bottom: 1px solid black;
    }

    li {
        text-decoration: none;
        list-style: none;
        padding: 10px 30px;
        margin: 10px;
        min-width: 200px;
        font-size: 15px;
        text-align: center;
        background-color: rgba(0, 0, 0, .2);
        border-radius: 10px;
        cursor: pointer;
        position: relative;
        transition: transform 0.3s ease;
    }

    .close-btn {
        display: none;
        position: absolute;
        right: 10px;
        top: 50%;
        transform: translateY(-50%);
        font-size: 20px;
        font-weight: bold;
        color: rgba(0, 0, 0, 0.5);
        cursor: pointer;
        width: 20px;
        height: 20px;
        line-height: 18px;
        text-align: center;
        border-radius: 50%;
        transition: all 0.2s ease;
    }

    .close-btn:hover {
        display: inherit;
    }

    li:hover .close-btn {
        display: inherit;
    }

    li::before {
        content: '';
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background: radial-gradient(circle 80px at var(--x, 0) var(--y, 0), 
                                rgba(20, 20, 20, 0.3), 
                                transparent);
        opacity: 0;
        transition: opacity 0.3s;
        z-index: -1;
        border-radius: 10px;
    }

    li:hover::before {
        opacity: 1;
    }
</style>