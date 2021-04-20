<template>
  <div class="col-3 background">
    <div class="card text-center vault-card d-flex justify-content-center">
      <h4>
        {{ vaultsProp.name }}
      </h4>
      <div class="card-img-overlay d-flex align-items-end">
        <div class="row">
          <div class="col-12 ">
            <br>
            <i class="fa fa-trash text-danger text-left" @click="deleteVault" v-if="vaultsProp.creatorId == state.account.id" aria-hidden="true"></i>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { logger } from '../utils/Logger'

export default {
  name: 'AccountVaultComponent',
  props: {
    vaultsProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {
      state,
      deleteVault() {
        try {
          if (window.confirm('Are you sure you want to delete this Vault?')) {
            vaultsService.deleteVault(props.vaultsProp.id)
          }
        } catch (error) {
          logger.log(error)
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

.vault-card:hover{
  transform: translateY(-2px);
  box-shadow: 2px 8px 16px 2px aqua;
}
.vault-card{
  transition: all .3s;
}

.vault-card{
 height: 250px;
  width: 250px;
}

// .vault-card{
//   height: 80px;
//   width: 100px;
// }
.background{
  background-color: black;
}
</style>
