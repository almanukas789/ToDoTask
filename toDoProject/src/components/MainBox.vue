<template>
  <div class="container">
    <br/>
    <div v-for="item in wdata" :key="item.id" class="box">
      <p><strong>Day: </strong>{{item.date}}</p>
      <p>{{item.task}}</p>
      <p>{{ item.status }}</p>
    </div>
    <br/>
  </div>
</template>
<script>
export default {
  props: ['wdata'],
  data () {
    return {
    }
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
