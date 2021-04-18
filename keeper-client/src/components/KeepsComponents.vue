<template>
  <div class="card-container keep-cards m-2">
    <div class="card">
      <img
        class="card-img pic"
        :src="keepProp.img"
        alt="Card image"
      >
      <div class="card-img-overlay d-flex align-items-end">
        <div class="row">
          <div class="col-12 text-light">
            <h4 class="keep-name text-left ">
              {{ keepProp.name }}
            </h4>
            <i class="fas fa-user-circle"></i>
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
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.keep-cards{
  transition: all .3s;
}

.pic{
  height: 150px;
  width: auto;
  box-shadow: 2px 6px 8px 2px #aa50e2;
  transition: 0.3s ease-in-out;
}
.keep-cards:hover{
  transform: translateY(-2px);
  box-shadow: 2px 8px 16px 2px aqua;
}
.keep-cards{
  transition: all .3s;
}

</style>
