<template>
  <div class="container">
    <br/>
    <div v-for="item in wdata" :key="item.id" class="box">
      <p class="title is-5">{{item.title}}</p>
      <p class="subtitle">{{ item.completed }}</p>
    </div>
  </div>
</template>
<script>
export default {
  props: ['wdata'],
  data () {
    return {}
  }
}
</script>
<style>
.box{
  margin-left: 5px;
  margin-right: 5px;
  margin-top: 5px;
  border-radius: 20px;
  background-color: #BEB7A4 !important;
}
.container{
  background-color: black;
  border-radius: 25px;
  margin-right: 10px;
}
</style>
