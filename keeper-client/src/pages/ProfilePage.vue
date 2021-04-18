<template>
  <div class="ProfilePage">
    <h5>Welcome to the profile's page</h5>

    <!-- <img :src="state.profiles.picture" alt="">
    <profileComponent v-for="pc in state.profile" :key="pc.id" :profile-prop="pc" /> -->
    {{ profiles }}
  </div>
</template>

<script>
import { computed, onMounted, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { profilesService } from '../services/ProfileService'

export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      profiles: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account)
    })
    onMounted(() => {
      profilesService.GetProfileById(route.params.id)
    })
    return {
      state,
      profiles: computed(() => AppState.profile)

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
