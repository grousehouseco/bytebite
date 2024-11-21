<script setup>

  import { inject } from 'vue';
  const routeHelper = inject('routeHelper')
  import * as rh from '../../router/route-constants'
  const props = defineProps(['path'])
  function getBreadcrumbs(){
    let arr = routeHelper.splitUrlToParts(props.value)
    let key = arr[arr.length - 1]
    return rh.breadcrumbs.filter(crumb => {crumb.route === key})
  }
</script>
<template>
  <div class="ml-4 breadcrumbs font-bold">
    <ul>
      <li v-for="part in getBreadcrumbs().breadcrumbs" :key="part">
        {{ part }}
      </li>
    </ul>
  </div>
</template>