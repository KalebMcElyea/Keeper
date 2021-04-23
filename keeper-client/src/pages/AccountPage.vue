<template>
  <div class="row m-2 container-fluid flex-grow-1 card-columns" v-if="state.keeps">
    <div class="col-1 about text-left mt-5">
      <img class="rounded acc-img" :src="account.picture" alt="" />
    </div>

    <h1 class="text-light col-6 mt-2 pt-3">
      <span class="name-font">{{ account.name }}</span>
      <br>
      <h4 class="count-font mt-2">
        Vaults: {{ state.vaults.length }}
      </h4>
      <h4 class="count-font">
        Keeps: {{ state.keeps.length }}
      </h4>
    </h1>
    <div class="col-12 mt-5">
      <!-- <button type="button" class="btn btn-dark mb-5" data-toggle="modal" data-target="#createKeep">
        Create a Keep
      </button> -->

      <!-- START KEEPS MODAL -->
      <div class="modal fade" id="createKeep" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title title-font">
                Create A Keep
              </h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body  m-2">
              <form @submit.prevent="createKeep">
                <div class="form-group m-2">
                  <input type="text"
                         name="title"
                         id="title"
                         class="form-control font"
                         placeholder="Enter Keep Name"
                         aria-describedby="helpId"
                         v-model="state.newKeep.name"
                  >
                  <br>
                  <input type="text"
                         name="title"
                         id="title"
                         class="form-control font"
                         placeholder="Enter Keep Description"
                         aria-describedby="helpId"
                         v-model="state.newKeep.description"
                  >
                  <br>
                  <input type="text"
                         name="img"
                         id="img"
                         class="form-control font"
                         placeholder="Enter img url"
                         aria-describedby="helpId"
                         v-model="state.newKeep.img"
                  >
                </div>
              </form>
            </div>
            <form>
              <div class="modal-footer">
                <button type="button" class="btn btn-danger font" data-dismiss="modal">
                  Close
                </button>
                <button class="btn btn-dark font" @click="createKeep">
                  Create Keep
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
      <!--END OF KEEPS MODAL -->

      <!--START OF VAULTS MODAL -->
      <div class="modal fade" id="createVault" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h1 class="modal-title font">
                Create A Vault
              </h1>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body  m-2">
              <form @submit.prevent="createVault">
                <div class="form-group m-2">
                  <input type="text"
                         name="title"
                         id="title"
                         class="form-control font"
                         placeholder="Enter Keep Name"
                         aria-describedby="helpId"
                         v-model="state.newVault.name"
                  >
                  <br>
                  <input type="text"
                         name="title"
                         id="title"
                         class="form-control font"
                         placeholder="Enter Keep Description"
                         aria-describedby="helpId"
                         v-model="state.newVault.description"
                  >
                  <br>
                  <label for="">{{ state.newKeep.isPrivate }}</label>
                  <span class="font">Private?</span><input type="checkbox" v-model="state.newVault.isPrivate" class="m-2">
                  <p>
                    <small class="font">
                      You want to make this vault private?
                    </small>
                  </p>
                </div>
              </form>
            </div>
            <form>
              <div class="modal-footer button-font">
                <button type="button" class="btn btn-danger font text-dark" data-dismiss="modal">
                  Close
                </button>
                <button class="btn btn-dark font" @click="createVault">
                  Create Vault
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>

      <div class="row mt-5">
        <div class="col-12">
          <h1 class=" text-light mb-3 vaultFont">
            Vaults: <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#createVault">
              <i class="fa fa-plus" aria-hidden="true"></i>
            </button>
          </h1>
        </div>
      </div>
      <div class="row underline">
        <AccountVault-component v-for="val in state.vaults" :key="val.id" :vaults-prop="val" />
      </div>

      <div class="row mt-5">
        <div class="col-12">
          <h1 class="text-light ml-3 keepFont">
            Keeps: <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#createKeep">
              <i class="fa fa-plus" aria-hidden="true"></i>
            </button>
          </h1>
          <div class="col-12 d-flex ">
            <div class="row">
              <AccountKeep-component v-for="keep in state.keeps" :key="keep.id" :keeps-prop="keep" />
            </div>
          </div>
        </div>
      </div>
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
      vaultsService.getVaultsByAccountId()
    })

    return {
      state,
      account: computed(() => AppState.account),
      createKeep() {
        keepsService.createKeep(state.newKeep)
        state.newKeep = {}
      },
      createVault() {
        vaultsService.createVault(state.newVault)
        state.newVault = {}
      }
    }
  }
}
</script>

<style scoped>
img {
  max-height: 200px;
  max-width: 200px;
}
.background{
  background-color: black;
}
.font{
  font-size: 18px;
  font-family: 'Lato', sans-serif;
}
.underline{
  text-decoration: none;
}
.button-font{
  font-family: 'Playfair Display', serif;
}
.title-font{
  font-size: 23px;
  font-family: 'Lato', sans-serif;
  font-weight: bolder;
  text-shadow: black 2px 4px 4px 0;
}
.close{
  color: red;
}
.close:hover{
  cursor: pointer;
  transform: translateY(-1px);
}
.button-color{
  color: black
}
.keepFont{
font-size: 30px;
font-family: 'Lato', sans-serif;
}
.vaultFont{
  font-size: 30px;
  font-family: 'Lato', sans-serif;
}
.count-font{
  font-family: 'Lato', sans-serif;
  font-size: 25px;
}
.name-font{
  font-family: 'Lato', sans-serif;
  font-size: 45px;
}

</style>
