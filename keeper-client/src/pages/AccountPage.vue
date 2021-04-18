<template>
  <div class="row m-2" v-if="state.keeps">
    <div class="col-3 about text-left mt-5">
      <img class="rounded" :src="account.picture" alt="" />
    </div>
    <div class="col-2 mt-5">
      <h1>
        {{ account.name }}
      </h1>
      <span class="m-2">
        <form @submit.prevent="createKeep">
          <input type="text" v-model="state.newKeep.img" placeholder="Img Url">
          <input type="text" v-model="state.newKeep.name" placeholder="Enter a name">
          <input type="text" v-model="state.newKeep.description" placeholder="Enter a description">
          <label for="">{{ state.newKeep.isPrivate }}</label>
          Private?<input type="checkbox" v-model="state.newKeep.isPrivate" class="m-2">
          <br>
          <button type="submit" class="btn btn-dark mt-1">
            Create Keep
          </button>
        </form>
      </span>
    </div>
  </div>
  <div class="row">
    <div class="col-12">
      <h1>
        Keeps <i class="fa fa-plus-circle" aria-hidden="true"></i>
      </h1>
      <AccountKeep-component v-for="ak in state.keeps" :key="ak.id" :keeps-prop="ak" />
    </div>
    <div>
      <AccountVault-component v-for="val in state.vaults" :key="val.id" :vaults-prop="val" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'

export default {
  name: 'Account',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      newKeep: {},
      vaults: computed(() => AppState.vaults),
      newVault: {}
    })

    onMounted(() => {
      keepsService.getKeepsByAccountId()
      vaultsService.getVaultByAccountId()
    })

    return {
      state,
      account: computed(() => AppState.account),
      createKeep() {
        keepsService.createKeep(state.newKeep)
        state.newKeep = {}
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 200px;
}
.background{
  background-color: black;
}
</style>
