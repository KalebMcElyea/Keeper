<template>
  <div class="keep-cards m-2"
       data-toggle="modal"
       :data-target="'#keepModal' + keepsProp.id"
  >
    <div class="card mb-0 rounded">
      <img
        class="card-img pic"
        :src="keepsProp.img"
        alt="Card image"
      >
      <div class="card-img-overlay d-flex align-items-end ">
        <div class="row">
          <div class="col-12 text-light">
            <h4 class="keep-name text-left text-light font">
              {{ keepsProp.name }}
            </h4>
            <i class="fa fa-trash text-danger trash" @click="deleteKeep" v-if="keepsProp.creatorId == state.account.id" aria-hidden="true"></i>
          </div>
        </div>
      </div>
    </div>
    <ActiveKeepComponents :keep="keepsProp" />
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
  transition: 0.3s ease-in-out;
}

.keep-cards:hover{
  // transform: translateY(-10px);
  box-shadow: 3px 3px 8px 2px aqua;
  transition: 0.3s ease-in-out;
}
.keep-cards{
  transition: all .4s;
}
.font{
font-family: 'Lato', sans-serif;
color: white;
font-size: 30px;
text-shadow: 0px 2px 3px #000,  2px 2px 3px #000, 2px 0px 0 #000, 0px 0px 0 #000;
}
.trash{
color: white;
font-size: 20px;
text-shadow: -1px 1px 2px #000,  1px 1px 2px #000, 1px -1px 0 #000, -1px -1px 0 #000;
}
.trash:hover{
  transform: translateY(-2px);
  cursor: pointer;
}
.rounded{
border-radius: 100px;
  background: #000000;
}
</style>
