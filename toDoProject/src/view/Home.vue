<template>
    <div id="top">
      <addModal
      :isVisible=isVisible
      @toggleModal="toggleModal"
      @updateData="updateData"
      />
        <NavBar/>
            <div class="columns">
              <div class="column is-narrow">
               <SideBar @toggleModal="toggleModal" @updateData="updateData"/>
              </div>
              <div class="column">
                <MainBox
                :wdata="wdata"
                @updateData="updateData"
                />
              </div>
            </div>
        <button @click="hello">Hello</button>
    </div>
</template>

<script>
import AddModal from '../components/AddModal.vue'
import NavBar from '../components/NavBar.vue'
import SideBar from '../components/SideBar.vue'
import MainBox from '../components/MainBox.vue'
import axios from 'axios'
export default {
  components: {
    NavBar,
    SideBar,
    MainBox,
    AddModal
  },
  data () {
    return {
      wdata: [],
      refresh: 50,
      isVisible: false
    }
  },
  methods: {
    toggleModal () {
      this.isVisible = !this.isVisible
    },
    updateData () {
      axios
        .get(this.$apiUrl)
        .then((r) => (this.wdata = r.data))
        .catch((error) => {
          console.log(error)
          this.errored = true
        })
    },
    hello () {
      console.log(this.wdata)
    }
  },
  mounted () {
    this.updateData()
  }
}
</script>
<style>
.main-container{
  background-color: red;
}
.envcard{
  margin-left: 20px;
  margin-right: 20px;
}
</style>
