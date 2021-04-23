<template>
  <div class="ProfilePage row" v-if="state.profileKeeps">
    <div class="text-light 2 col-12 ml-4 pt-2" v-if="state.profile">
      <img :src="state.profile.picture" alt="">
      <h4 class="pt-2 font">
        {{ state.profile.name }}
      </h4>
      <br>
      <h5 class="font">
        Vaults:  {{ state.profileVaults.length }}
      </h5>
      <br>
      <h5 class="font">
        Keeps: {{ state.profileKeeps.length }}
      </h5>
      <br>
      <br>
    </div>
    <div class="row">
      <div class="col-12">
        <h3 class="text-light ml-5 font">
          Vaults:
        </h3>
      </div>
    </div>
    <div class="row vaults" data-toggle="modal" data-target="#exampleModal">
      <vaultsComponent v-for="v in state.profileVaults" :key="v.id" :vault-prop="v" />
    </div>
    <div class="col-12">
      <h3 class="text-light ml-5 font">
        Keeps:
      </h3>

      <div class="row pic ml-3" data-toggle="modal" data-target="#exampleModal">
        <keepsComponent v-for="k in state.profileKeeps" :key="k.id" :keep-prop="k" />
      </div>
    </div>
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
      profile: computed(() => AppState.profiles),
      profileKeeps: computed(() => AppState.profileKeeps),
      profileVaults: computed(() => AppState.profileVaults),
      keeps: computed(() => AppState.keeps),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account)

    })
    onMounted(() => {
      profilesService.GetProfileById(route.params.id)
      profilesService.getKeepsByProfileId(route.params.id)
      profilesService.getVaultsByProfileId(route.params.id)
    })
    return {
      state,
      profiles: computed(() => AppState.profile)

    }
  },
  components: {}
}
</script>

<style lan
    KeepComponentg="scss" scoped>
.font{
  font-family: 'Lato', sans-serif;
}

</style>
