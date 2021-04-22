<template>
  <div class="vaults-component m-5 vault-cards">
    <div class="d-flex card d-flex justify-content-center">
      <div class="row">
        <div class="col-12 text-center">
          <router-link :to="{name:'Vault', params:{id: vaultProp.id}}" class="underline">
            <h4 class="vault-name text-dark text-center justify-content-center">
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

}

.vault-cards:hover{
  transform: translateY(-2px);
  box-shadow: 2px 8px 16px 2px aqua;
  cursor: pointer;
}
.vault-cards{
  transition: all .3s;
}

.font{
  color: aqua;
  box-shadow: #aa50e2;
}

.font:hover{
  transform: translateY(-1px);
}
.card{
  height: 200px;
  width: 200px
}
.underline{
  text-decoration: none;
}

</style>
