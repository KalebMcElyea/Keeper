<template>
  <div class="SelectVault">
    <router-link :to="{name:'Vault', params:{id:vaultProp.id}}" class="noUnderline">
      <button @click="addToVault" class="dropdown-item">
        {{ vaultProp.name }}
      </button>
    </router-link>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { vaultKeepsService } from '../services/VaultKeepsService'
import router from '../router'
export default {
  name: 'SelectVault',
  props: {
    vaultProp: { type: Object, required: true },
    keepProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
    })
    return {
      state,
      async addToVault() {
        await vaultKeepsService.createVaultKeep({ vaultId: props.vaultProp.id, keepId: props.keepProp.id })
        router.push({ name: 'Vault', params: { id: props.vaultProp.id } })
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.noUnderline{
  text-decoration: none;
}
</style>
