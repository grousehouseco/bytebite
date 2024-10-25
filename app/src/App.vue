<script setup>
  import { RouterView } from 'vue-router'
  import LeftNav from './components/nav/left-nav.vue';
</script>

<template>
  <div class="w-full h-screen flex flex-row">
    <LeftNav/>
    <div class="w-full h-screen flex flex-col">
      <main>
        <RouterView />
      </main>
    </div>
  </div>
</template>