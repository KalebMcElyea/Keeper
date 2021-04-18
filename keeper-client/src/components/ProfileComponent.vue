<template>
  <div class="card-container keep-cards m-2">
    <div class="card">
      <!-- <img
        class="card-img pic"
        :src="keepsProp.img"
        alt="Card image"
      > -->
      <div class="card-img-overlay d-flex align-items-end">
        <div class="row">
          <div class="col-12 text-light">
            <h4 class="keep-name text-left ">
              {{ profileProp }}
            </h4>
            <i class="trash fa fa-trash" @click="deleteKeep" v-if="keepsProp.creatorId == state.account.id" aria-hidden="true"></i>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  name: 'ProfileComponent',
  props: {
    profileProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
      activeProfile: computed(() => AppState.activeProfile)
    })
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.trash{
  color:rgb(161, 46, 46);
}
.trash:hover{
  transform: translateY(-1px);
}

</style>
