<template>
  <div class="navbar bg-base-200 gap-1">
    <div class="dropdown dropdown-start">
      <div class="flex-none">
        <button class="btn btn-ghost btn-circle" role="button">
          <span class="material-symbols-rounded">menu</span>
        </button>
        <ul class="menu bg-base-200 rounded-box w-56 dropdown-content mt-2">
          <li><a>Item 1</a></li>
          <li><a>Item 2</a></li>
          <li><a>Item 3</a></li>
        </ul>
      </div>
    </div>
    
    <div class="flex-1">
      <h1 class="prose prose-xl">Bytebite</h1>
    </div>
    <div class="flex-none">
      <button class="btn btn-square btn-ghost">
        <span class="material-symbols-rounded">more_vert</span>
      </button>
    </div>
  </div>
</template>