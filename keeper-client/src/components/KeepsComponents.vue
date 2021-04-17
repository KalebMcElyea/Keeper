<template>
  <div class="keepsComponent col-3 card container-fluid m-1">
    <img :src="keepProp.img" alt="">
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

</style>
