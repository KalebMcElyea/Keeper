<template>
  <div class="ActiveKeepComponents">
    <div class="modal fade bd-example-modal-lg"
         :id="'keepModal' + keep.id"
         tabindex="-1"
         role="dialog"
         aria-labelledby="keepModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title" id="keepModalLabel">
              {{ keep.name }}
            </h1>
            <br>

            <button type="button" class="close text-danger" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="row">
            <div class="modal-body col-6 ml-1">
              <img
                class="card-img pic"
                :src="keep.img"
                alt="Card image"
              >
            </div>
            <i class="fa fa-eye text-center view-icon mt-2" aria-hidden="true"> : 0</i>
            <i class="fa fa-archive vault-icon mt-2" aria-hidden="true"> : 0</i>
            <i class="fa fa-share-alt share-icon mt-2" aria-hidden="true"> : 0</i>
            <div class="col-5 mt-5">
              <h5 class="move-text ml-2">
                {{ keep.description }}
                <br>
                Leverage agile frameworks to provide a robust synopsis for high level overviews. Iterative approaches to corporate strategy foster collaborative thinking to further the overall value proposition. Organically grow the holistic world view of disruptive innovation via workplace diversity and empowerment.
              </h5>
              <hr>
            </div>
            <div>
              <div class="footer m-5">
                <button type="button" class="btn btn-danger m-2 font" data-dismiss="modal">
                  Close
                </button>
                <div class="dropdown open">
                  <button
                    type="button"
                    id="triggerId"
                    class="btn btn-dark dropdown-toggle font"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                  >
                    ADD TO VAULT
                  </button>
                  <div class="dropdown-menu" aria-labelledby="triggerId">
                    <select-vault
                      data-dismiss="modal"
                      aria-label="Close"
                      v-for="v in state.profileVaults"
                      :key="v.id"
                      :vault-prop="v"
                      :keep-prop="keep"
                    />
                  </div>
                </div>
                <router-link :to="{name:'Profile', params:{id:keep.creatorId}}">
                  <i class="fa fa-user-circle ml-5 text-dark fa-lg" aria-hidden="true"></i>
                  {{ keep.creator.name }}
                </router-link>
                <i class="fa fa-trash text-danger fa-lg ml-5" @click="deleteKeep" v-if="keep.creatorId == state.account.id" aria-hidden="true"></i>
              </div>
            </div>
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
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
import SelectVault from './SelectVault.vue'
export default {
  name: 'ActiveKeepComponents',

  props: {
    keep: {
      type: Object,
      required: true
    }

  },

  setup(props) {
    const state = reactive({
      account: computed(() => AppState.account),
      profileVaults: computed(() => AppState.profileVaults)
    })
    return {
      state,
      deleteKeep() {
        try {
          if (window.confirm('Are you sure you want to delete this KEEP?')) {
            keepsService.deleteKeep(props.keep.id)
          }
        } catch (error) {
          logger.log(error)
        }
      }
    }
  },
  components: { SelectVault }
}
</script>

<style lang="scss" scoped>
.view-icon{
  position: absolute;
  right: 290px;
}

.share-icon{
  position: absolute;
  right: 135px;
}
.vault-icon{
  position: absolute;
  right: 215px;
}
.modal-title{
  font-family: 'Lato', sans-serif;
}
.modal-dialog{
  font-family: 'Lato', sans-serif;
}
.font{
  font-family: 'Lato', sans-serif;
}

</style>
