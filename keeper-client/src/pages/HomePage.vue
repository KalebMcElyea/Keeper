<template>
  <div class="home d-flex container-fluid justify-content-center card columns">
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
import { vaultsService } from '../services/VaultsService'

export default {
  name: 'Home',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account)
    })

    onMounted(() => {
      keepsService.getKeeps()
      onMounted(() => vaultsService.getVaultsByAccountId(state.account.id))
    })
    return { state }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  background-color: black;
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
