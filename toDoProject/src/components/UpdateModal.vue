<template>
<div>
  <Notification
  :type="type"
  :message="message"
  />
  <div class="modal is-active" v-if="updateModalVisability">
    <div class="modal-background" @click="toggleModal"></div>
    <div class="modal-card">
      <header class="modal-card-head">
        <p class="modal-card-title">Update your task</p>
        <button class="delete" aria-label="close" @click="toggleModal"></button>
      </header>
      <section class="modal-card-body">
        <p class="modal-body-text">Dedicated time for the task:  </p>
        <div class="select">
          <select v-model="updateData.time">
            <option value="10">10 Minutes</option>
            <option value="20">20 Minutes</option>
            <option value="30">30 Minutes</option>
            <option value="40">40 Minutes</option>
            <option value="50">50 Minutes</option>
            <option value="60">60 Minutes</option>
          </select>
        </div>
        <p class="modal-body-text">Task:</p>
        <textarea class="textarea" placeholder="Enter your task here" v-model="updateData.task" maxlength="100" required></textarea>
        <p style="color:red" v-if="infoMsgState">{{ infoMsg }}</p>
      </section>
      <footer class="modal-card-foot">
        <button class="button is-success" @click="save">Save changes</button>
        <button class="button" @click="toggleModal">Cancel</button>
      </footer>
    </div>
  </div>
</div>
</template>
<script>
import axios from 'axios'
import Notification from './Notification.vue'
export default {
  components: {
    Notification
  },
  props: ['updateData', 'updateModalVisability'],
  data () {
    return {
      infoMsgState: false,
      infoMsg: '',
      message: '',
      type: ''
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
    async save () {
      if (this.updateData.time === undefined) {
        this.infoMsg = 'Please dedicate the time for your task!'
        this.infoMsgState = true
      } else if (this.updateData.task === undefined || this.updateData.task === '') {
        this.infoMsg = 'Please enter your task!'
        this.infoMsgState = true
      } else {
        this.infoMsgState = false
        await axios
          .put(this.$apiUrl + '?id=' + this.updateData.ID + '&task=' + this.updateData.task + '&time=' + this.updateData.time + '&status=' + this.updateData.status)
          .then(() => {
            this.notification('Task was updated!', 'success')
          })
          .catch((error) => {
            this.notification(error.response, 'danger')
          })
        await this.toggleModal()
      }
    },
    toggleModal () {
      this.infoMsgState = false
      this.$emit('toggleUpdateModal')
    }
  }
}
</script>
<style>
.modal-body-text{
    color:#BEB7A4
}
.modal-card-foot{
    background-color: black;
    border-color: #BEB7A4;
}
.modal-card-body{
    background-color: black !important;
}
.modal-card-head{
    background-color: black !important;
    border-color: #BEB7A4;
}
.modal-card-title{
    color: #c19921;
}
</style>
