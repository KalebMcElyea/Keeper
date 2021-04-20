<template>
  <div class="home d-flex container-fluid justify-content-center">
    <div class="row pic">
      <keepsComponent v-for="k in state.keeps" :key="k.id" :keep-prop="k" />
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep)
    })
    onMounted(() => keepsService.getKeeps())
    return { state }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 150px;
    width: 1500px;
  }
}
.pic{
  height: 150px;
  width: auto;
  transition: 0.3s ease-in-out;
}

</style>
