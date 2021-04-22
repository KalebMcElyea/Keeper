<template>
  <div class="VaultPage">
    <h5 class="text-light ml-4">
      Total Keeps in this Vault: {{ state.keeps.length }}
    </h5>
    <h5 class="text-light ml-2">
      <br>
      <vaultKeepComponent v-for="k in state.keeps" :key="k.id" :keep-prop="k" />
    </h5>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
import { vaultKeepsService } from '../services/VaultKeepsService'
export default {
  name: 'VaultPage',
  setup(props) {
    const route = useRoute()
    const state = reactive({
      account: computed(() => AppState.account),
      activeVaultKeeps: computed(() => AppState.activeVaultKeeps),
      keeps: computed(() => AppState.keeps),
      activeVault: computed(() => AppState.activeVault)
    })
    onMounted(async() => {
      try {
        await vaultsService.getVaultById(route.params.id)
        await vaultKeepsService.getKeepsByVaultId(route.params.id)
        await keepsService.getKeepsByPublicVault(route.params.id)
      } catch (error) {
        logger.log(error)
      }
    })
    return {
      state,
      removeKeep() {
        try {
          if (window.confirm('Are you sure you want to remove this Keep from this Vault?')) {
            vaultKeepsService.deleteVaultKeep(props.keepProp.id)
          }
        } catch (error) {
          logger.log(error)
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
