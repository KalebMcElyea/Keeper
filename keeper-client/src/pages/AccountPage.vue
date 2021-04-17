<template>
  <div class="row m-2" v-if="state.keeps">
    <div class="col-3 about text-left mt-5">
      <img class="rounded" :src="account.picture" alt="" />
    </div>
    <div class="col-2 mt-5">
      <h1>
        {{ account.name }}
      </h1>
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
      keeps: computed(() => AppState.keeps)
    })

    onMounted(() => keepsService.getKeepsByAccountId())

    return {
      state,
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 200px;
}
</style>
