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
        <span>
        </span></span>
    </div>
    <div class="mt-5 card " v-if="state.keeps">
      {{ state.keeps }}
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'

export default {
  name: 'Account',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      newKeep: {}
    })

    onMounted(() => keepsService.getKeepsByAccountId())

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
</style>
