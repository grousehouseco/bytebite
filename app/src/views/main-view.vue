<script setup>
  import { RouterView } from 'vue-router'
  import TitleBar from '../components/nav/title-bar.vue'
  import LeftNav from '../components/nav/left-nav.vue'
  defineProps({
    id: String
  })
</script>

<template>
  <div class="w-full h-screen flex flex-col bg-base-200 pb-10 pr-10">
    <TitleBar :userId="id"/>
    <div class="w-full h-screen flex flex-row">
      <LeftNav :userId="id"/>
      <div class="card size-full bg-base-100 shadow-md p-4">
        <RouterView class="card-body flex-none"/>
      </div>
    </div>
  </div>
</template>