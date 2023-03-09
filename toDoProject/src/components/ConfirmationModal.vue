<template>
<div>
    <Notification
    :type="type"
    :message="message"
    />
    <div class="modal is-active" v-if="confirmationVisability">
        <div class="modal-background" @click="toggleVisability"></div>
        <div class="modal-card">
          <header class="modal-card-head">
            <p class="modal-card-title">Are you sure want to delete your Todo task?</p>
            <button @click="toggleVisability" class="delete" aria-label="close"></button>
          </header>
          <footer class="modal-card-foot">
            <button class="button is-danger" @click="deleteTask">Yes</button>
            <button class="button" @click="toggleVisability">No</button>
          </footer>
        </div>
      </div>
</div>
</template>
<script>
import axios from 'axios'
import Notification from '../components/Notification.vue'
export default {
  components: {
    Notification
  },
  props: ['confirmationVisability', 'holder'],
  data () {
    return {
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
    toggleVisability () {
      this.$emit('toggleConfirmation')
    },
    async deleteTask () {
      await axios
        .delete(this.$apiUrl + '?id=' + this.holder)
        .then(() => {
          this.notification('Deleted successfully!', 'success')
        })
        .catch(function (error) {
          this.notification(error.response, 'danger')
        })
      this.toggleVisability()
      await this.$emit('updateData')
    }
  }
}
</script>
