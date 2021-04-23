<template>
  <div class="vaults-component m-5 vault-cards">
    <div class="d-flex card d-flex justify-content-center">
      <div class="row">
        <div class="col-12 text-center">
          <router-link :to="{name:'Vault', params:{id: vaultProp.id}}" class="underline">
            <h4 class="vault-name text-center justify-content-center font">
              {{ vaultProp.name }}
            </h4>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import { reactive } from '@vue/reactivity'
export default {
  name: 'VaultsComponent',
  props: {
    vaultProp: {
      type: Object,
      required: true
    }

  },
  setup() {
    const state = reactive({

    })
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.vault-cards{
  transition: all .3s;
  background-color: gray;
}

.vault-cards:hover{
  transform: translateY(-10px);
  box-shadow: 2px 8px 16px 2px aqua;
  cursor: pointer;
}
.vault-cards{
  transition: all .3s;
}

.font{
font-family: 'Lato', sans-serif;
color: rgb(255, 255, 255);
font-size: 35px;
text-shadow: 0px 2px 3px #000,  2px 2px 3px #000, 2px 0px 0 #000, 0px 0px 0 #000;
}

.font:hover{
  transform: translateY(-1px);
}
.card{
  height: 200px;
  width: 200px;
  background-color: gray;
}
.underline{
  text-decoration: none;
}

</style>
