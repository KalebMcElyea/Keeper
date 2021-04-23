<template>
  <div class="card-container keep-cards m-2 justify-content-center ml-5">
    <div class="card">
      <img
        class="card card-img pic"
        :src="keepProp.img"
        alt="Card image"
      >
      <div class="card-img-overlay d-flex align-items-end">
        <div class="row">
          <div class="col-12 text-dark mt-5">
            <h4 class="keep-name text-light font"
                data-toggle="modal"
                :data-target="'#keepModal' + keepProp.id"
            >
              {{ keepProp.name }}
            </h4>
            <router-link :to="{name:'Profile', params:{id:keepProp.creatorId}}">
              <i class="icon fa fa-user-circle mr-5" aria-hidden="true"></i>
            </router-link>
            <i class="fas fa-minus-circle fa-xs text-danger remove" @click="removeKeep"></i>
            <ActiveKeepComponents :keep="keepProp" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import { reactive } from '@vue/reactivity'
import { vaultKeepsService } from '../services/VaultKeepsService'
import { logger } from '../utils/Logger'

export default {
  name: 'VaultKeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({

    })
    return {
      state,
      removeKeep() {
        try {
          if (window.confirm('Are you sure you want to remove this Keep from this Vault?')) {
            vaultKeepsService.deleteVaultKeep(props.keepProp.vaultKeepId)
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
.keep-cards{
  transition: all .3s;
}

.pic{
  height: 300px;
  width: 300px;
  box-shadow: 2px 6px 8px 2px #aa50e2;
  transition: 0.3s ease-in-out;
}
.keep-cards:hover{
  // transform: translateY(-2px);
  box-shadow: 2px 8px 16px 2px aqua;
}
.keep-cards{
  transition: all .2s;
}

.font{
  color: aqua;
  box-shadow: #aa50e2;
}

.font:hover{
  transform: translateY(-2px);
}
.font{
  font-family: 'Libre Baskerville', serif;
  color: white;
font-size: 20px;
text-shadow: -1px 1px 2px #000,  1px 1px 2px #000, 1px -1px 0 #000, -1px -1px 0 #000;
}
.icon:hover{
  transform: translateY(-3px);
}
.icon{
  color:rgb(212, 211, 211);
font-size: 20px;
text-shadow: -1px 1px 2px #000,  1px 1px 2px #000, 1px -1px 0 #000, -1px -1px 0 #000;
}
.keep-name:hover{
cursor: pointer;
}
.remove:hover{
  transform: translateY(-3px);
  cursor: pointer;
}
.remove{
  position: absolute;
  bottom: 250px;
  left: 270px;
  text-shadow: -1px 1px 2px #000,  1px 1px 2px #000, 1px -1px 0 #000, -1px -1px 0 #000;

}

</style>
