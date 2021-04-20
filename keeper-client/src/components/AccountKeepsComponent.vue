<template>
  <div class="card-container keep-cards m-2">
    <div class="card">
      <img
        class="card-img pic"
        :src="keepsProp.img"
        alt="Card image"
      >
      <div class="card-img-overlay d-flex align-items-end">
        <div class="row">
          <div class="col-12 text-light">
            <h4 class="keep-name text-left text-light">
              {{ keepsProp.name }}
            </h4>
            <i class="fa fa-trash text-danger" @click="deleteKeep" v-if="keepsProp.creatorId == state.account.id" aria-hidden="true"></i>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'

export default {
  name: 'AccountKeepComponent',
  props: {
    keepsProp: {
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
      deleteKeep() {
        try {
          if (window.confirm('Are you sure you want to delete this KEEP?')) {
            keepsService.deleteKeep(props.keepsProp.id)
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
.pic{
  height: 250px;
  width: 300px;
  box-shadow: 2px 4px 4px 2px  #aa50e2;
  transition: 0.3s ease-in-out;
}
.keep-cards:hover{
  transform: translateY(-10px);

}
.keep-cards{
  transition: all .3s;
}
</style>
