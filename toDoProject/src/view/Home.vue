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
        <SideBar
        @toggleModal="toggleModal"
        @updateData="updateData"
        @notCompleted="filter"
        @completed="filter"/>
      </div>
      <div class="column">
        <MainBox
        :tableTitle="tableTitle"
        :wdata="wdata"
        @updateData="updateData"
        />
      </div>
    </div>
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
      isVisible: false,
      tableTitle: ''
    }
  },
  methods: {
    toggleModal () {
      this.isVisible = !this.isVisible
    },
    filter (filter) {
      this.updateData()
      setTimeout(() => {
        let temp = this.wdata.filter(function (r) {
          return r.status === filter
        })
        this.wdata = temp
        if (filter === '0') {
          this.tableTitle = 'Not completed To-dos'
        }
        if (filter === '1') {
          this.tableTitle = 'Completed To-dos'
        }
      }, 20)
    },
    updateData () {
      axios
        .get(this.$apiUrl)
        .then((r) => (this.wdata = r.data))
        .catch((error) => {
          console.log(error)
        })
      this.tableTitle = 'All To-dos'
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
