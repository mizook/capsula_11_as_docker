<template>
  <Teleport to="body">
    <div
      v-if="modelValue"
      class="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center p-4 z-50"
    >
      <div class="bg-white rounded-lg shadow-xl w-full max-w-md">
        <div class="p-6">
          <h2 class="text-2xl font-bold mb-4 text-gray-800">
            Agregar Estudiante
          </h2>
          <form @submit.prevent="handleSubmit">
            <div class="space-y-4">
              <div>
                <label
                  for="name"
                  class="block text-sm font-medium text-gray-700"
                  >Nombre completo</label
                >
                <input
                  id="name"
                  v-model="form.name"
                  type="text"
                  required
                  class="h-10 pl-2 border-2 block w-full rounded-md border-gray-300 shadow-sm"
                />
              </div>
              <div>
                <label for="rut" class="block text-sm font-medium text-gray-700"
                  >RUT</label
                >
                <input
                  id="rut"
                  v-model="form.rut"
                  type="text"
                  required
                  class="h-10 pl-2 border-2 block w-full rounded-md border-gray-300 shadow-sm"
                />
              </div>
              <div>
                <label
                  for="email"
                  class="block text-sm font-medium text-gray-700"
                  >Email</label
                >
                <input
                  id="email"
                  v-model="form.email"
                  type="email"
                  required
                  class="h-10 pl-2 border-2 block w-full rounded-md border-gray-300 shadow-sm"
                />
              </div>
              <div>
                <label
                  for="enrollmentDate"
                  class="block text-sm font-medium text-gray-700"
                  >Fecha de inscripción</label
                >
                <input
                  id="enrollmentDate"
                  v-model="form.enrollmentDate"
                  type="date"
                  onfocus="this.showPicker()"
                  required
                  class="h-10 pl-2 border-2 block w-full rounded-md border-gray-300 shadow-sm"
                />
              </div>
            </div>
            <div class="mt-6 flex justify-end space-x-3">
              <button
                type="button"
                @click="closeModal"
                class="px-4 py-2 border border-gray-300 rounded-md text-sm font-medium text-gray-700 hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-[#388098] ease-in-out duration-300"
              >
                Cancelar
              </button>
              <button
                type="submit"
                class="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-[#28445c] hover:bg-[#388098] focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-[#388098] ease-in-out duration-300"
              >
                Agregar
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<script setup>
import { ref } from "vue";

const props = defineProps({
  modelValue: {
    type: Boolean,
    required: true,
  },
});

const emit = defineEmits(["update:modelValue", "add-student"]);

const form = ref({
  name: "",
  rut: "",
  email: "",
  enrollmentDate: "",
});

const closeModal = () => {
  emit("update:modelValue", false);
};

const handleSubmit = () => {
  const enrollmentDateISO = new Date(form.value.enrollmentDate).toISOString();
  emit("add-student", { ...form.value, enrollmentDate: enrollmentDateISO });

  form.value = {
    name: "",
    rut: "",
    email: "",
    enrollmentDate: "",
  };
};
</script>
