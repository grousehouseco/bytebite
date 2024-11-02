<script setup>
  // import { useRoute, useRouter } from 'vue-router'
  // const route = useRoute()
  // const router = useRouter()
</script>
<template>
  <div class="navbar bg-base-200 gap-1 h-24">
    <div class="ml-4 breadcrumbs font-bold">
      <ul>
        <li><a>Home</a></li>
        <li><a>Documents</a></li>
        <li>Add Document</li>
      </ul>
    </div>
    <div class="grow"></div>
    <details class="dropdown dropdown-end">
      <summary class="avatar" role="button">
        <div class="w-12 rounded-xl">
          <img src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp" />
        </div>
      </summary>
      <ul class="menu dropdown-content bg-base-100 rounded-box z-[1] w-52 p-2 shadow">
        <li><a>Item 1</a></li>
        <li><a>Item 2</a></li>
      </ul>
    </details>
  </div>
</template>