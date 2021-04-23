<template>
  <div class="card-container keep-cards m-2 justify-content-center ml-5">
    <div class="card"
         data-toggle="modal"
         :data-target="'#keepModal' + keepProp.id"
    >
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
            <ActiveKeepComponents :keep="keepProp" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import { reactive } from '@vue/reactivity'

export default {
  name: 'KeepsComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({

    })
    return { state }
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
  color: white;
  font-size: 20px;
  text-shadow: -1px 1px 2px #000, 1px 1px 2px #000, 1px -1px 0 #000, -1px -1px 0 #000;
}

.font:hover{
  transform: translateY(-2px);
}
.font{
  font-family: 'Libre Baskerville', serif;
}
.icon:hover{
  transform: translateY(-3px);
}
.icon{
  color:rgb(212, 211, 211);
   text-shadow: -1px 1px 2px #000, 1px 1px 2px #000, 1px -1px 0 #000, -1px -1px 0 #000;
}
.keep-name:hover{
cursor: pointer;
}
.card:hover{
  cursor: pointer;
}

</style>
