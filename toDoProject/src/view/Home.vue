<template>
  <div id="top" style="">
    <Notification
    :type="type"
    :message="message"
    />
    <ConfirmationModal
    :confirmationVisability="confirmationVisability"
    :holder="holder"
    @toggleConfirmation="toggleConfirmation"
    @updateData="updateData"
    />
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
        @toggleConfirmation="toggleConfirmation"
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
import ConfirmationModal from '../components/ConfirmationModal.vue'
import Notification from '../components/Notification.vue'
export default {
  components: {
    NavBar,
    SideBar,
    MainBox,
    AddModal,
    ConfirmationModal,
    Notification
  },
  data () {
    return {
      wdata: [],
      refresh: 50,
      isVisible: false,
      tableTitle: '',
      confirmationVisability: false,
      holder: '',
      type: '',
      message: ''
    }
  },
  methods: {
    notification (message, type) {
      this.type = type
      this.message = message
      setTimeout(() => {
        this.type = ''
        this.message = ''
      }, 2000)
    },
    toggleConfirmation (item) {
      this.confirmationVisability = !this.confirmationVisability
      this.holder = item
    },
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
        if (filter === false) {
          this.tableTitle = 'Not completed To-dos'
        }
        if (filter === true) {
          this.tableTitle = 'Completed To-dos'
        }
      }, 20)
    },
    async updateData () {
      try {
        this.wdata = await this.$crud.getData()
        this.tableTitle = 'All To-dos'
      } catch (error) {
        this.notification(error, 'danger')
      }
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
