<template>
    <article v-if="type === 'success'" class="message is-success">
        <div class="message-header">
          <p>{{ message }}</p>
        </div>
      </article>
      <article v-else-if="type === 'danger'" class="message is-danger">
        <div class="message-header">
          <p class="messagestyle">{{ message }}</p>
        </div>
      </article>
</template>
<script>
export default {
  props: {
    message: {
      type: String,
      default: 'Ups'
    },
    type: {
      type: String,
      default: ''
    }
  },
  data () {
    return {
    }
  }
}
</script>
<style>
.message-header {
    justify-content: center;
}
.message {
  position: fixed;
  width: 20%;
  z-index: 9999;
  text-align: center;
  top: 0;
  left: 0;
  right: 0;
  margin: auto;
}
</style>
