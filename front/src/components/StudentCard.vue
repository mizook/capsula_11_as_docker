<template>
  <div
    class="bg-white rounded-lg shadow-md overflow-hidden hover:shadow-lg transition duration-300 ease-in-out"
  >
    <div class="p-6">
      <div class="flex items-center mb-4">
        <UserIcon class="w-8 h-8 text-[#28445c] mr-3" />
        <h2 class="text-xl font-semibold text-gray-800">{{ student.name }}</h2>
      </div>
      <div class="text-gray-600 space-y-2">
        <p><span class="font-medium">RUT:</span> {{ student.rut }}</p>
        <p><span class="font-medium">Email:</span> {{ student.email }}</p>
        <p>
          <span class="font-medium">Fecha de inscripción:</span>
          {{ formatDate(student.enrollmentDate) }}
        </p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { UserIcon } from "lucide-vue-next";

defineProps({
  student: {
    type: Object,
    required: true,
  },
});

const formatDate = (dateString) => {
  const options = { year: "numeric", month: "long", day: "numeric" };
  return new Date(dateString).toLocaleDateString("es-CL", options);
};
</script>
