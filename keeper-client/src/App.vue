<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
footer {
  position: fixed;
  left: 0;
  bottom: 0;
  width: 100%;
  background-color: rgb(78, 78, 78);
  color: white;
  text-align: center;
}
</style>
