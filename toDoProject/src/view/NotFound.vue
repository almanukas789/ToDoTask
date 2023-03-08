<template>
<div>
    <NavBar/>
    <div id="example">
        <h1 style="text-align:center;font-size: 60px;">404</h1>
        <h1 style="text-align:center;font-size: 30px;">Not found anything</h1>
    </div>
</div>
</template>
<script>
import NavBar from '../components/NavBar.vue'
export default {
  components: {
    NavBar
  },
  data () {
    return {
    }
  }
}
</script>
<style>
#example {
    top: 50%;
    left: 50%;
    width: 30em;
    height: 18em;
    margin-top: -9em;
    margin-left: -15em;
    position: fixed;
  }
</style>
